﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using DemoApp.Modal;

namespace DemoApp
{
    public partial class MainForm : Form
    {
        private List<Product> products;
        private List<Category> categories;
        public MainForm()
        {
            InitializeComponent();
            Task.Run(async () => await LoadDataFromAPI()).Wait();
        }

        private async Task<string> GetTokenAsync(string username, string password)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    string url = "https://localhost:44377/api/user/login";
                    var loginData = new
                    {
                        Username = username,
                        Password = password
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(loginData), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonString = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(jsonString);
                        return tokenResponse.Data.AccessToken;
                    }
                    else
                    {
                        MessageBox.Show("Failed to login: " + response.ReasonPhrase);
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
                return null;
            }
        }
        private async Task LoadDataFromAPI()
        {
            try
            {
                string token = await GetTokenAsync("admin", "admin123");

                if (string.IsNullOrEmpty(token))
                {
                    MessageBox.Show("Token is null or empty.");
                    return;
                }

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    // Load categories
                    string categoryUrl = "https://localhost:44377/api/Category";
                    HttpResponseMessage categoryResponse = await client.GetAsync(categoryUrl);
                    if (categoryResponse.IsSuccessStatusCode)
                    {
                        string categoryJsonString = await categoryResponse.Content.ReadAsStringAsync();
                        categories = JsonConvert.DeserializeObject<List<Category>>(categoryJsonString);
                        categories.Insert(0, new Category { Id = "999", Name = "All" });
                        cmbCategory.DataSource = categories;
                        cmbCategory.DisplayMember = "Name";
                        cmbCategory.ValueMember = "Id";
                    }
                    else
                    {
                        MessageBox.Show("Failed to load categories from API: " + categoryResponse.ReasonPhrase);
                        return;
                    }

                    // Load products
                    string productUrl = "https://localhost:44377/api/Product";
                    HttpResponseMessage productResponse = await client.GetAsync(productUrl);
                    if (productResponse.IsSuccessStatusCode)
                    {
                        string productJsonString = await productResponse.Content.ReadAsStringAsync();
                        products = JsonConvert.DeserializeObject<List<Product>>(productJsonString);
                        dgvProducts.DataSource = products;
                    }
                    else
                    {
                        MessageBox.Show("Failed to load products from API: " + productResponse.ReasonPhrase);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
        }

        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedValue != null)
            {
                string categoryId = cmbCategory.SelectedValue.ToString();
                if (categoryId == "999")
                {
                    dgvProducts.DataSource = products;
                }
                else
                {
                    if (categoryId != "DemoApp.Modal.Category")
                    {
                        var filteredproducts = products.Where(p => p.CategoryId.ToString() == categoryId).ToList();
                        dgvProducts.DataSource = filteredproducts;
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadDataFromAPI();
        }
    }

}