using UnityEngine;

[System.Serializable]

public class Isotope{
    // Creating all the fields
    public string isotopeName;
    public float isotopeHalfLife;
    public bool isotopeStability;
    public string isotopePrint;

    // Check that determins Band for isotopePrint
    public int Band()
    {
        if (isotopeStability)
        {
            // Stable
            return 0;
        }
        else if (isotopeHalfLife < 0.3)
        {
            // "Quicker than a blink"
            return 1;
        }
        else if (isotopeHalfLife < 60)
        {
            // Under 1 min
            return 2;
        }
        else if (isotopeHalfLife < 3600)
        {
            // Under an hour
            return 3;
        }
        else if (isotopeHalfLife < 86400)
        {
            // Under a day
            return 4;
        }
        else if (isotopeHalfLife < 31557600)
        {
            // Under 1 year
            return 5;
        }
        else if (isotopeHalfLife < 3155760000)
        {
            // Under 100 years
            return 6;
        }
        else
        {
            // Longer than 100 years
            return 7;
        }
    }

    public string Line(){
        if (Band() == 0)
        {
            return "This one is stable! It never pops.";
        }
        else if (Band() == 1)
        {
            return "Quicker than a blink!";
        }
        else if (Band() == 2)
        {
            return "Under a minute! I wonder if you could run a km that fast.";
        }
        else if (Band() == 3)
        {
            return "Under an hour. This is around the same time as the average coffee break!";
        }
        else if (Band() == 4)
        {
            return "Under a day! Maybe you could have breakfast and dinner in that time.";
        }
        else if (Band() == 5)
        {
            return "Under 1 whole year! Would you remember it if you started counting from the start?";
        }
        else if (Band() == 6)
        {
            return "Under 100 years! I wonder if you know anyone this old.";
        }
        else if (Band() == 7)
        {
            return "Older than 100 years! I dont think anyone has lived that long...";
        }
        else
        {
            return "Older than 100 years! I dont think anyone has lived that long...";
        }
    }
}
