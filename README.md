# Overview
**BmiPlugin** is a C# plugin for BMI calculating and gender assessment.


# Getting started

Here are the details of using the **BmiPlugin** and a complete usage example.


### Installation

You can download and install package by 
[searching in NuGet](https://www.nuget.org/packages/BmiPlugin)
or by inserting the following code in Package Manager Console:
```Shell
Install-Package BmiPlugin
```

### Implementation

To use **BmiPlugin** you need to embed this namespace into your code.

```C#
using BmiPlugin;
```

### BMI calculating

You can do it with **Height**, **Weigth** and **Age** (optional) params:

```C#
double bmi = Bmi.GetBmi(height: 180, weigth: 80, age: 20);
```

or you can set the **UsingData** earlier and run the method with it:

```C#
Bmi.UsingData = new BiometricData
{
    Height = 180,
    Weigth = 80,
    Age = 20,
};

double bmi = Bmi.GetBmi();
```

> #### Notes
> - you must set **Height** and **Weigth** values, else you'll get the Exception;
> - **Age** value is not necessary, because it has the default value;

### Gender asessment calculating

> #### Notes
> - the result value characterizes the ratio of the set of input data to the reference values.
> - it is a number of double type in range from 0 to 1, where 0-0,5 - female, 0,5-1 - male.
> - but 1 is long, fat or old man, and 0 is full opposite.

First of all, you must set the **UsingData** or initialize a new instance of the class:

```C#
var Data = new BiometricData
{
    Height = 180,
    Weigth = 80,
    Age = 20,
};
```

Then you need to start the machine learning process with this Data.
Also you can set the **Deepness** value for machine learning:

```C#
Bmi.Start(Data, Deepness.High);
```

> #### Notes
> - you must set values for not less than 2 properties, else you'll get the Exception;
> - this method has default value - **Deepness.Medium**, and you can run it without params.
> - if you'll set **Deepness.No** value then it wouldn't be any iterations of machine learning.

And finally you need to run the calculating method:

```C#
double gender = Bmi.GetGenderAssessment();
```

You can also set anew instance of the **BiometricData** class as a parameter:

```C#
double gender = Bmi.GetGenderAssessment(new BiometricData
{
  Height = 176,
  Weigth = 66,
  Age = 22
});
```

### Complete example code
Here is an example of code with MVVM pattern:

```C#
using BmiPlugin;

internal class BmiViewModel
{
  public double Height { get; set; } = 180;
  public double Weigth { get; set; } = 80;
  public double Age { get; set; } = 20;

  public Command StartBmiCommand => new Command(sender => StartBmi());

  private void StartBmi()
  {
    Bmi.UsingData = new BiometricData
    {
      Height = Height,
      Weigth = Weigth,
      Age = Age,
    };

    Bmi.Start(Deepness.High);

    double bmi = Bmi.GetBmi();
    double gender = Bmi.GetGenderAssessment();
  }
}
```

> your **BiometricData** properties values with double types must be more than 0 and less than 4294967295 (uint.MaxValue), else you'll get the Exception;

# License

You can check out the full license
[here](https://github.com/Aiwprton-tcdp/BmiPlugin/blob/master/LICENSE.md)

This project is licensed under the terms of the MIT license.