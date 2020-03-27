﻿using ArcadiaParties.Data.Abstractions.Repositories;
using System.Threading.Tasks;

namespace ArcadiaParties.Data.Repositories
{
    public class AssistantTokenRepository : IAssistantTokenRepository
    {
        public async Task<string> GetToken()
        {
            var bearer = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IllNRUxIVDBndmIwbXhvU0RvWWZvbWpxZmpZVSIsImtpZCI6IllNRUxIVDBndmIwbXhvU0RvWWZvbWpxZmpZVSJ9.eyJhdWQiOiJhMmNjYjIyMS02MGUyLTQ3YjgtYjI4Yy1iZjg4YTU5ZjdmNGEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9mYTRlOWMxZi02MjIyLTQ0M2QtYTA4My0yOGY4MGMxZmZlZmMvIiwiaWF0IjoxNTg1Mjk5OTcxLCJuYmYiOjE1ODUyOTk5NzEsImV4cCI6MTU4NTMwMzg3MSwiYWNyIjoiMSIsImFpbyI6IkFVUUF1LzhQQUFBQXA3eDlENzBJajZnUUJyazdaQ1pBVmRaWWxVTWFYZ2pJL2Q1bUUrMnJpSURhdDQ1WXBGcWpXaXREcWtvVlBYYkhyc2Z3VDQvNnBacUFHTytEaXRGeTJRPT0iLCJhbXIiOlsicHdkIiwibWZhIl0sImFwcGlkIjoiYTJjY2IyMjEtNjBlMi00N2I4LWIyOGMtYmY4OGE1OWY3ZjRhIiwiYXBwaWRhY3IiOiIwIiwiZmFtaWx5X25hbWUiOiJLdXpuZXRzb3ZhIiwiZ2l2ZW5fbmFtZSI6IkVrYXRlcmluYSIsImlwYWRkciI6IjE4NS4xMzQuNzQuNSIsIm5hbWUiOiJLdXpuZXRzb3ZhLCBFa2F0ZXJpbmEiLCJvaWQiOiI5NjgwMGQyMC02MDNiLTRhZTUtOGM5MS03YzdlN2Q3YWE5OGEiLCJvbnByZW1fc2lkIjoiUy0xLTUtMjEtMzE3Mjc1NTkzLTExMzkwOTk3ODQtMTUwMTE4NzkxMS0xODcwNCIsInNjcCI6IlVzZXIuUmVhZCIsInN1YiI6IjAzMHVpUFdyTHpDRmlOdTFrcmpwNjJfOG5MS0o0UFdDVkkyT2pWdVJTLVkiLCJ0aWQiOiJmYTRlOWMxZi02MjIyLTQ0M2QtYTA4My0yOGY4MGMxZmZlZmMiLCJ1bmlxdWVfbmFtZSI6ImVrYXRlcmluYS5rdXpuZXRzb3ZhQGFyY2FkaWEuc3BiLnJ1IiwidXBuIjoiZWthdGVyaW5hLmt1em5ldHNvdmFAYXJjYWRpYS5zcGIucnUiLCJ1dGkiOiJpeDVvS3hTM1pVcTNlY2VCN1A4SUFBIiwidmVyIjoiMS4wIn0.JIrVaCgNV-nwwKhowFFLozWo6Kgol415c_s2eZ2BEiOtnQ5Bp4OGKvuTBbNj6mrCeQNQ_PTthRQKov324Zyxn99RsPDbRzc8zLA2KPZBcn7rc7ZM42etoI8bWnoDNHw9rOeG7Cu6Mn4cS5p3Oevfs6cNSnv4H6AhRzQDzLq6X1clLTt-QDS1Olsq7tSxeYVbPPcMlNbrIiEIHipVMQSDRDmdguO70ANL-taZKl3tt56PpZfJCVESPQ6relWoLEKLgXsfyeLAOHYYYf1bVy2nmo_7plsvjF4-buvilpmsPXWkGzNfJf42YVq4pVVYfGlUfaB2AZ-YWui1VhHOFkF_5Q";
            return bearer;
        }
    }
}