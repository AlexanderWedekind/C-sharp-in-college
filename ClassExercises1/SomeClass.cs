namespace ClassExercises1;

public class ClassOne
{
    string someName = "";
    int propertyCount = 0;

    Dictionary<string, int> propertyIndeces = new Dictionary<string, int>();
    string[,] propertArray = new string[5,2];

    public void Foam(string soap)
    {
        this.propertArray[propertyCount, 0] = "foam";
        this.propertArray[propertyCount, 1] = $"there is '{soap}'-type soap in the water, making bubbles.";
        propertyIndeces.Add("foam", propertyCount);
        IncrementPropertyCount();
    }

    public void IncrementPropertyCount()
    {
        this.propertyCount += 1;
    }

    public int GetSomeNum()
    {
        return this.propertyCount;
    }

    public void PropertyA(string letter)
    {
        this.propertArray[propertyCount, 0] = "foam";
        this.propertArray[propertyCount, 1] = $"there is '{soap}'-type soap in the water, making bubbles.";
        propertyIndeces.Add("foam", propertyCount);
        IncrementPropertyCount();
    }

    ClassOne(string name)
    {
        this.someName = name;
    }
}