#Post-Covid scenario:#

People are now free to travel everywhere but because of the pandemic, a lot of hotels
went bankrupt. Some former famous travel places are left with only one hotel.
You’ve been given the responsibility to develop a booking API for the very last hotel in Cancun.
The requirements are:
- API will be maintained by the hotel’s IT department.
- As it’s the very last hotel, the quality of service must be 99.99 to 100% => no downtime
- For the purpose of the test, we assume the hotel has only one room available
- To give a chance to everyone to book the room, the stay can’t be longer than 3 days
and can’t be reserved more than 30 days in advance.
- All reservations start at least the next day of booking,
- To simplify the use case, a “DAY’ in the hotel room starts from 00:00 to 23:59:59.
- Every end-user can check the room availability, place a reservation, cancel it or modify it.
- To simplify the API is insecure.





#Let's see...#
- API will be maintained by the hotel’s IT department.
	- Need to be easy to change parameters, easy to maintained
	
- As it’s the very last hotel, the quality of service must be 99.99 to 100% => no downtime
	- API Need ~0 downtime
	- AWS garantee - normaly < 99.99
	- Azure  garantee - < 99.99
	So.. the idea is use multi-cloud
	searching for options I found this >> use YugabyteDB to resolve problem with sabe DB in many clouds. Is a multi-cloud based DB.
	
	
- For the purpose of the test, we assume the hotel has only one room available
	- I can create only one room now, but is nice have a possibility to create others
	
- To give a chance to everyone to book the room, the stay can’t be longer than 3 days
and can’t be reserved more than 30 days in advance.
	- This things can be parameters or can be business rule
	
- All reservations start at least the next day of booking,
	- This is business rule
	
- To simplify the use case, a “DAY’ in the hotel room starts from 00:00 to 23:59:59.
	- This is business rule
- Every end-user can check the room availability, place a reservation, cancel it or modify it.
	- Each end-user need login/password
	- At least create JWT with user data, each user only can delete or update if do login.
	
- To simplify the API is insecure.
	- Dont use SSL/ cript data
	
	
	
	
#YugabyteDB Steps#

 docker pull yugabytedb/yugabyte:2.17.0.0-b24
 
 docker run -d --name yugabyte  -p7000:7000 -p9000:9000 -p5433:5433 -p9042:9042\
 yugabytedb/yugabyte:2.15.2.0-b87 bin/yugabyted start\
 --daemon=false
 
 
  #terminal - Docker Desktop#
 ysqlsh
 
 CREATE DATABASE ysql_booking;
 
 CREATE DATABASE ysql_identity;
 
 
 
 
 
 
 
 
 
 
#explaining my idea#
- Use two cloud providers (eg: AWS and Azure);
- Use Kubernetes, with this, you can use green/blue deployment (risk free updates);
- Use Kubernetes in both cloud providers;
- Use YugabyteDB in both cloud providers;
- Create a VPC between the clouds;
- Create rules of DNS, if one service stay off, you can use the other cloud.

![Alt text](/My_ideas.png)