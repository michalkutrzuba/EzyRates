namespace EzyRates.Web.Concepts.RatesApi.Mapper
{
    public static class StringExtensions
    {
        public static double ToDouble(this string @string)
        {
            return double.Parse(@string.Replace(',', '.'));
        }

        public static int ToInt(this string @string)
        {
            return int.Parse(@string);
        }
    }
}