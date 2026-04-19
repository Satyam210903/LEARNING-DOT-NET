using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TODO_Client_API.Models;

namespace TODO_Client_API
{
    public class StudentApiService
    {
        private readonly HttpClient _httpClient;
        private string? _jwtToken;

        // ================== CONSTRUCTOR ==================
        public StudentApiService(string baseUrl)
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        // ================== AUTHENTICATION ==================
        public async Task<string> LoginAsync(string username, string password)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/auth/login",
                new { username, password });

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (result == null || string.IsNullOrEmpty(result.Token))
                throw new Exception("Login failed: no token returned.");

            _jwtToken = result.Token;

            // Add JWT to all future requests
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _jwtToken);

            return _jwtToken;
        }

        public bool IsAuthenticated => !string.IsNullOrEmpty(_jwtToken);

        // ================== STUDENT OPERATIONS ==================

        // Get all students
        public async Task<List<Student>> GetStudentsAsync()
        {
            var response = await _httpClient.GetAsync("api/student");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Student>>()
                   ?? new List<Student>();
        }

        // Get student by Id
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/student/{id}");
            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<Student>();
        }

        // Add new students (server will attach User_id from JWT)
        public async Task<bool> AddStudentsAsync(List<Student> students)
        {
            if (students == null || students.Count == 0)
                return false;

            var response = await _httpClient.PostAsJsonAsync(
                "api/student/batch", students);

            return response.IsSuccessStatusCode;
        }

        // Update student (server will check ownership from JWT)
        public async Task<bool> UpdateStudentAsync(int id, Student student)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"api/student/{id}", student);

            return response.IsSuccessStatusCode;
        }

        // Delete student (server will check ownership from JWT)
        public async Task<bool> DeleteStudentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(
                $"api/student/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
