namespace SharedDto.DataTransferObjects;

public record TokenDto(string AccessToken, string RefreshToken, bool IsAuthSuccessful, string ErrorMessage);
//public class TokenDto
//{
//    public bool IsAuthSuccessful { get; set; }
//    public string ErrorMessage { get; set; }
//    public string Token { get; set; }
//    public string RefreshToken { get; set; }

//}
