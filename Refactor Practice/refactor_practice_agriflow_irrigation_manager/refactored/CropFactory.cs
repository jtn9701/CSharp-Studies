namespace Refactor
{
    public class CropFactory
    {
        public static ICrop CreateCrop(string cropName)
        {
            return cropName switch
            {
                "Almond" => new Almond(),
                "Corn" => new Corn(),
                "Grape" => new Grape(),
                "Lettuce" => new Lettuce(),
                "Tomato" => new Tomato(),
                _ => new GenericCrop()
            };
        }
    }
}