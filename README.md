# PersonTransform

This is a simple project that was built using TDD. The requirements are included below.

**Summary**

We are going to receive a JSON file with some Person data from a 3rd party
system. We need to transform this data into the correct format so that it can be
imported into our system. Create a console application that reads the JSON file,
transforms the data as needed, and writes that transformed data to another JSON
file that can then be retrieved by our system for processing. The console
application should meet these criteria:

-   Use Clean Code and SOLID programming principles

    -   Loose coupling should be achieved by using Dependency Injection with the
        help of the Castle Windsor DI container.

    -   Use the Repository pattern when working with Person data.

-   Use TDD to build the application with automated unit tests

    -   Unit testing should be implemented using the NUnit, Moq, and AutoFixture
        testing frameworks. 

-   Use Newtonsoft.Json for JSON parsing.

**Imported Person Data**

-   The imported JSON Person data file contains an array of Person objects. The
    Person objects have the following properties:

| Property Name   | Type                                                                         |
|-----------------|------------------------------------------------------------------------------|
| name            | string                                                                       |
| address         | string                                                                       |
| observationDate | date                                                                         |
| gender          | string – possible values: “M” and “F”                                        |
| favoriteColor   | string – possible values: “blue”, “red”, “green”, “purple”, “pink”, “orange” |

**Exported Person Data**

-   The exported JSON Person objects must contain the following properties:

| Property Name   | Type    |
|-----------------|---------|
| name            | string  |
| address         | string  |
| acquisitionDate | date    |
| isCool          | boolean |

**Transform Criteria**

The transformed data must meet the following criteria:

-   If the imported Person has a gender of “M”, prepend the exported Person name
    with “Mr.” If the imported Person has a gender of “F”, prepend the exported
    Person name with “Ms.”

-   The exported Person isCool property should be set to “true” if the imported
    Person favoriteColor property has the values of “purple”, “pink”, or
    “green”. The exported Person isCool property should be set to “false” if the
    imported Person favoriteColor property has the values of “blue”, “red”, or
    “orange”.

-   If the exported Person isCool property is set to “true”, then the exported
    Person acquisitionDate property should be set to two years after the
    imported Person observationDate property. If the exported Person isCool
    property is set to “false”, then the exported Person acquisitionDate
    property should be set to “null”. Determine the exported Person isCool
    property before setting the exported Person acquisitionDate property.

-   No transformation should occur for the address property. The imported Person
    address should merely be copied to the exported Person address.

**Other Requirements**

-   The paths for the imported and exported JSON Person data files should be
    read from the App.config file so that they are configurable after
    deployment.

To test the console application, run the included personImport.json file. The
output should match personExport.json, below.

