using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Cab Treasure System")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CabTreasure")]
[assembly: AssemblyCopyright("Copyright ©  2018")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("0e426622-4090-4010-b9f5-d4ae5d4f434f")]

// Version information for an assembly consists of the following four values:
//

//      Major Version
//      Minor Version 
//      Build Number
//      Revision
[assembly: AssemblyFileVersion("5.2.655.0")]
//////
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("5.2.655")]

//5.1.655
// fix ryde247 issue

//4/210.655
//add booking fee setting form in general

//4.209.655
//add active/inactive functionality in escort
//add escort name and escort price in jobs list report

//4.208.655
//add track escort in onboarding driver

//4.207.655
//add pincode in escort

//4.206.655
//add printer setting for A4 also VAT No in Invoice Report
//resize template21_rptCompanyInvoice to A4 size
//show Escort drop down in booking form

//4.1.654 //save agent comm and charge on set fare table 2 new columns

// 4.120.653

// admin/standard usertype on company weblogin 4.93.653

// 4.362.651
// Add change driver option from booking list   [FOR DELTA CARS BASINGSTOKE]````````````````````````````````````````````````````````

// 4.333.651 [15/08/2022]
// SHOW  PAYMENT TYPE ON DRIVER RENT & COMMISSION STATEMENT FORM
// CCA ACCOUNT WASN'T SHOWING ON SINGLE COMPANY INVOICE
// DRIVER JOB SUMMARY REPORT    [REPORT=>DRIVER=> DRIVER JOB SUMMARY REPORT]
// RENT REPORT                  [REPORT=>DRIVER=>RENT REPORT]

// 4.191.651
// upload document on cloud
// document table filepath increase length
// third party email api integrate.


// Newtonsoft.Json.JsonConvert.SerializeObject -- ALWAYS USE THIS FOR SERIALIZATION
/*
 * //4.172.651 
* TUESDAY - 01 FEB 2022*
1.    When a booking saved as QUOTATION, its sending an email as booking confirmed as in below image.When it’s a QUOTATION booking, it should ask for confirmation to send email or not. If user choose to send email then it should send as BOOKING QUOTAION instead of BOOKING CONFIRMATION.
show fares (total fare) on quotation email

2. When a quotation booking is confirmed its sending below confirmation email which is different to normal confirmation email.It shouldn’t show any fare as on the normal booking confirmation

3. Can we change the job list report column ordering only for milenium executive

Pickup date/time | Ref | driver | A/c fare | payment type | Fare | destination | passenger | pickup | via | Payment Ref | Journey type | special req | Extra | Driver parking | Driver Waiting | A/c Parking | A/C waiting | Vehicle | status | Booked by

4. Show discount value on invoice.

5. Show Discount on Account invoice statement.
*/

//4.167.651 
// 1) job list report => export bookings in csv
// 2) on booking page if account price is 0 then its showing account price same as driver price

//4.154.651 // recover from dashboard onboard grid refresh all terminals

/*
Date : 18-05-2021
Version : v4.118.645
Changes:
1) on multivehicle and multibooking no need to insert coordinates to pick plot.
2) on zones list enable delete zone option to work.
*/


/* CHOW TAXIS
updated on 26/05/2021 @ 17:00
Version - v4.112.645.0

1.After inputting destination cursor goes to vehicle type 

2.After inputting via point cursor goes to vehicle type 

3.Periodic pda message to drivers 

4.Auto calculate fare from caller ID 

5.On break plot 

6.Fare not coming on multi vehicle booking  - PICK FROM API SERVICE

7.Home or end on multi vehicle booking 

8.For some customers on caller ID it shows very wrong fares

9. attributes not saving on return booking.

*/



/*
Date : 18-05-2021
Version : v4.109.645
Changes:
1) want autocalculate fares when you pick booking from callerid popup history and search booking.
   (i have added NEW PERMISSION IN SECURITY PERMISSION PAGE
    NEW BOOKING => "AUTOCALCULATE FARES ON PICK BOOKING"
   if its ticked then system will autocalculate fares when pick booking from callerid or search booking.
*/


/*
    Date : 05-05-2021
Version : v4.102.645
Changes: Dial a cab (Complaint)
1) Driver waiting list, if waiting mins exceeds 1 hour 30 mins then its showing 2 hour 30 mins, its adding extra 1 hour in mins.
*/



/*Date : 30-04-2021
Version : v4.93.645
Changes:
  1. On Create single invoice page, show the breakdown of total charges. vat,adminfee etc.
  2. On Account invoice list, show total charges including vat and adminfee
  3. On UnPaid invoice list, show total charges including vat and adminfee
*/

//4.97.644 
// rtf formula 5

// 4.18.643
// quotation date crieria fixed

// multibooking editing => return via swap fixed
// 4.68.620.0 
// i) surcharge on plot wise by date & time criteria only for mileage fares
//
// 4.69.620.0 
// i) surcharge on plot wise by date & time criteria on both fixed and mileage fares,
//(OAKWOOD STATION CARS REQUESTED)


// 4.75.620
// Fixed : when you open different driver commission/Rent list , its opening multiple windows.




// 4.79.620 till 4.82.620
// BOOKING FORM 2 CHANGES :
// 1) asap pickup time
// 2) account dropdown autosuggess
// 3) exclude driver

//4.86.620
/*
 * Mole Valley Taxis Changes.
1. Enable FAre Increment  (show apply on fixed fares and plot to plot
2. Enable Surcharge on Plot on all type of fares
3. Show Account Password field on booking if its enabled from account info.
*/


//4.29.621
/*
 
1. FIXED : When you make a multibooking with W/R journeytype its make a return journey multibooking. (ESCALATED BY TANVEER FOR CAMBRIDGE TAXIS)
2. NEW : ADLANTE CARD PAYMENT  => 4.26.621
3. FIXED : When you login a dispatch sometimes price plot grid comes up and driver plots grid not showing up.
*/


// NEED TO UPDATE ON BLANK DB
// UPDATE STP_UPDATEJOBANDROUTE FROM ALPHA EAGLE CARS TO SET  AUTOPLOT ZONE ON CLEAR JOB STATUS
// ivr new scripts for driver abop



// 4.30.621
// invoice template 10 changes for molevalley



// 4.45.621
// On Rent Pay and Comm Pay show only Active Drivers


// 4.1.628
// Account Invoice Payment Report


//  4.10.628
// escort work in booking template 2


//  4.23.628.0
// woking taxis 5 points


//  4.1.630.0
// OXFORD TRAVEL => ESCORT , ESCORT PRICE IN BOOKING
// DEPARTMENT WISE PICKUP AND DROPOFF


//  4.2.630.0
// agent commission

//  4.5.630.0
// NEW REPORTS => DRIVER COMMISSION DETAIL REPORT =>FALCON CARS


//4.9.630.0
/*1.	Driver Earning Report  => (Changes) – (See attachment1.png)
They want us to remove Hrs, Break, Decline, N/S, Earning, Avg/Job, Avg/Day & Avg/Hrs columns and add four new columns with following details.

1.	After Commission they need another “Owed” column which contains the result of Account jobs – Driver Commission.
2.	Driver Expenditure - Contains parking charges or congestion charges.
3.	Driver PDA Rent.
4.	Net Due – which is Owed + Driver Expenditure.

2)In driver earning the drivers waiting time is not shown.  (ON F8 DRIVER EARNING => Change : THEY WANT Waiting & Parking Column
  E.g if in a job, fare is 65 and waiting  is 14.in driver earning  it will show only 65 . not (65+14)= 79.  


    3)  FULL POSTCODE FIXED FARES SUBCOMPANY WISE – CHANGES : INCLUDE FIXED FARES FOR FULL POSTCODE WITH PARTICULAR SUBCOMPANY. 
              [ THEY DON’T WANT TO CREATE PLOTS FURTHER, SO FULL POSTCODE TO FULL POSTCODE FARE BY EACH SUBCOMPANY SHOULD WORK]
add post code to post code fare starting with KT22, client added many fares of that Railway station post code in system eg KT22 to KT22,  KT22 0UT to  KT22 8QX, system is not calculating fares of Post code (KT22) second part, as mentioned Post code starting digits


 * 
 * 
 * */


//4.10.630.0
//ADD PICKUPDATE COLUMN ON CALLERID POPUP.

//
// 4.21.638
// EMBASSY CARS
// 1) ON SENDBOOKINGDIRECTEMAIL PROPERTY=> SEND EMAIL ON SAVE BOOKING ADD MODE
// 2) BOOKING RECEIPT TEMPLATE 4
// 3) ON CARD PAYMENT+> SEND RECEIPT EMAIL CONFIRMATION POPUP
// 4) CREDIT CARD CHARGES LIMIT
// 5) ON COPY BOOKINGS +> COPY NOTES AND PAYMENT COMMENTS


// 4.4.640
// on driver rent statement, pick booking it was only picking up account jobs.


//"4.1.642,  round robin fare by subcompany, and return fares by tariff wise


//4.6.643, integrate round robin formula 4