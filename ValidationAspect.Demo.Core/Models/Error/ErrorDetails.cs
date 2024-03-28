using Newtonsoft.Json;

namespace ValidationAspect.Demo.Core.Models.Error
{
    public class ErrorDetails
    {
        public string? Message { get; set; }
        public string? Description { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
