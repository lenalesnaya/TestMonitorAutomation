using Bogus;

namespace Core.Utilites.Helpers
{
    public static class FakerHelper
    {
        public static readonly Faker Faker = new();

        public static string GetAlphabeticStringRandomValue(int length) =>
            Faker.Random.String2(length, "abcdefghijklmnopqrstuvwxyz" + "abcdefghijklmnopqrstuvwxyz".ToUpper());

        public static string GetNumericStringRandomValue(int length) =>
            Faker.Random.String(length, '0', '9');

        public static string GetAlphaNumericStringRandomValue(int minLength, int maxLength) =>
            Faker.Random.AlphaNumeric(new Random().Next(minLength, maxLength));

        public static string GetAlphaNumericStringRandomValue(int length) =>
            Faker.Random.AlphaNumeric(length);

        public static string GetAlphaSpecialSymbolsStringRandomValue(int length) =>
            Faker.Random.String2(length, "abcdefghijklmnopqrstuvwxyz" + "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~");

        public static string GetAlphaNumericSpecialSymbolsStringRandomValue(int length) =>
            Faker.Random.String(length, '!', '~');

        public static string GetCyrillicLettersStringRandomValue(int length) =>
            Faker.Random.String(length, 'А', 'я');

        public static string GetSymbolsSpecifiedRangeStringRandomValue(int length, char minValue, char maxValue) =>
            Faker.Random.String(length, minValue, maxValue);
    }
}