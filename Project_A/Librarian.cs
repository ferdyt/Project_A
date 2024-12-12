namespace Project_A
{
    public class Librarian : Person
    {
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }
        public Library Library { get; set; }

        public override void IntroduceYourself()
        {
            Console.WriteLine($"Привiт, я бiблiотекар. Мене звати {Name}. Мiй номер телефону: {PhoneNumber}.");
        }
    }
}
