# FortranSQL
Many thanks to brianberns for helping me to understand how to do this.  
See:  https://stackoverflow.com/questions/66859208/basic-model-of-a-f-program-using-mysql

As I built this, I found that you can't just "Add Reference" to MySql.Data.  As Brian suggested, it has to be done with a NuGet package.  I used:
PM> Install-Package MySql.Data -Version 8.0.23  (The version at the time)
PM> Install-Package System.Configuration.ConfigurationManager

If you love FORTRAN, this is the way to go.  
