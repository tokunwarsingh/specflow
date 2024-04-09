using SpecFlowFakeDataIntegration;
using System;

public static class TestDataGenerator
{
    public static RegistrationTestData GenerateRegistrationTestData()
    {
        var faker = new Bogus.Faker();

        return new RegistrationTestData
        {
            FirstName = faker.Name.FirstName(),
            LastName = faker.Name.LastName(),
            Email = faker.Internet.Email(),
            Phone = faker.Phone.PhoneNumber(),
            Gender = faker.PickRandom(new[] { "Male", "Female" }),
            Address = faker.Address.FullAddress(),
            CricketHobby = faker.Random.Bool(),
            MoviesHobby = faker.Random.Bool(),
            HockeyHobby = faker.Random.Bool(),
            Language = faker.PickRandom(new[] { "English", "French", "Spanish" }),
            Skill = faker.PickRandom(new[] { "Analytics", "APIs", "Android" }),
            Country = faker.PickRandom(new[] { "India" }),//faker.Address.Country(),
            DateOfBirth = faker.Random.Number(1, 31).ToString(),
            MonthOfBirth = faker.Date.Month(),
            YearOfBirth = faker.Date.Past(30).Year.ToString(),
            Password = faker.Internet.Password(),
            ConfirmPassword = faker.Internet.Password()
        };
    }
}