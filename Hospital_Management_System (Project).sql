select*from Doctors;
delete from Doctors where Login_id='Ashfaq_Doc_001';
select *from Medical_Test
update Medical_Test set TestType='Blood Test' where T_ID='Saim_Med>Test_1';
update Medical_Test set TestType='Blood Test' where Status='Under Process';


use Hospital_Management_System;
create table Bill
(
 B_id int primary key not null,
 P_id varchar (max),
 Name varchar (max),
 Department varchar(max),
 Admission_ID varchar (max),
 Admission_Date varchar(max),
 Total_Amount varchar(max),
 Status varchar(max)
)