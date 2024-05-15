# App_Desktop_Demo

## Setup:

1. **Run Project Web API:** Chạy dự án Web API của bạn.

2. **Lấy URL:** Sau khi dự án Web API chạy thành công, lấy URL của dự án và thay thế vào `BaseUrl`.

```csharp
public static class ApiUrls
{
    public const string BaseUrl = "https://localhost:44377/api/";
}
