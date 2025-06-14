namespace Tea.Shared.Models
{
    public class OmiseSource
    {
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Flow { get; set; } = string.Empty;
        public ScannableCode? ScannableCode { get; set; }
        public string ChargeStatus { get; set; } = string.Empty;
    }

    public class ScannableCode
    {
        public string Type { get; set; } = string.Empty;
        public QrCodeImage? Image { get; set; }
    }

    public class QrCodeImage
    {
        public string Id { get; set; } = string.Empty;
        public string Filename { get; set; } = string.Empty;
        public string DownloadUri { get; set; } = string.Empty;
        public string Kind { get; set; } = string.Empty;
    }

    public class OmiseCharge
    {
        public string Id { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public OmiseSource? Source { get; set; }
        public string AuthorizeUri { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool Paid { get; set; }
        public bool Authorized { get; set; }
        public string? FailureCode { get; set; }
        public string? FailureMessage { get; set; }
    }

    public class PaymentRequest
    {
        public decimal TotalAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<CartItem> Items { get; set; } = new();
    }
}