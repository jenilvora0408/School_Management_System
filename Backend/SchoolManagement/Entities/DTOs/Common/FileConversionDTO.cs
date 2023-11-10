namespace Entities.DTOs.Common
{
    public class FileConversionDTO
    {
        public List<byte[]> ByteFiles { get; set; } = null!;

        public List<string> FileNames { get; set; } = null!;
    }
}
