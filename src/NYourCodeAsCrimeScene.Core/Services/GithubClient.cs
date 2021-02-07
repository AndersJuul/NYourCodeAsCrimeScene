using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class GithubClient : IGithubClient
    {
        //Get all files from a repo
        public async Task<Directory> GetRootDirectory(string owner, string name, string accessToken, string[] fileExt)
        {
            try
            {
                var client = new HttpClient();
                var root = await ReadDirectory("root", client, $"https://api.github.com/repos/{owner}/{name}/contents/", accessToken, fileExt);
                client.Dispose();
                return root;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //recursively get the contents of all files and subdirectories within a directory 
        private static async Task<Directory> ReadDirectory(string name, HttpClient client, string uri,
            string accessToken, string[] fileExt)
        {
            Console.WriteLine("--Reading dir: " + uri);
            //get the directory contents
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.Headers.Add("Authorization",
                "Basic " + Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(string.Format("{0}:{1}", accessToken, "x-oauth-basic"))));
            request.Headers.Add("User-Agent", "lk-github-client");

            //parse result
            var response = await client.SendAsync(request);
            var jsonStr = await response.Content.ReadAsStringAsync();
            ;
            response.Dispose();
            var dirContents = JsonConvert.DeserializeObject<FileInfo[]>(jsonStr);

            //read in data
            Directory result;
            result.name = name;
            result.subDirs = new List<Directory>();
            result.files = new List<FileData>();
            foreach (var file in dirContents)
            {
                Console.WriteLine("  -- Reading file: " + file.name);
                if (file.type == "dir")
                {
                    //read in the subdirectory
                    var sub = await ReadDirectory(file.name, client, file._links.self, accessToken, fileExt);
                    result.subDirs.Add(sub);
                }
                else
                {
                    if (fileExt.Contains(file.type))
                    {
                        //get the file contents;
                        var downLoadUrl = new HttpRequestMessage(HttpMethod.Get, file.download_url);
                        downLoadUrl.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.UTF8.GetBytes($"{accessToken}:x-oauth-basic")));
                        request.Headers.Add("User-Agent", "lk-github-client");

                        var contentResponse = await client.SendAsync(downLoadUrl);
                        var content = await contentResponse.Content.ReadAsStringAsync();
                        contentResponse.Dispose();

                        FileData data;
                        data.name = file.name;
                        data.contents = content;

                        result.files.Add(data);
                    }
                }
            }

            return result;
        }
    }
}