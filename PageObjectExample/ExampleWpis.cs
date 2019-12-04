namespace PageObjectExample
{
    internal class ExampleWpis
    {
        public ExampleWpis()
        {
            Title = Faker.Name.FullName();
            ContentWpis = Faker.Name.FullName();
        }
        public string Title { get; }
        public string ContentWpis { get; }
    }
}
