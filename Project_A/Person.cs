namespace Project_A
{
    public abstract class Person
    {
        public string Name { get; set; }
        public Age Age { get; set; }
        public int PhoneNumber { get; set; }

        public abstract void IntroduceYourself();
    }
}
