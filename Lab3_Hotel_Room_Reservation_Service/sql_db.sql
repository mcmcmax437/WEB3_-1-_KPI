use hoteldb;
SELECT * FROM rooms;

DELETE FROM `hoteldb`.`rooms` WHERE Id = 4;

INSERT INTO `hoteldb`.`rooms`
(`Id`,
`Name`,
`Type`,
`Price`,
`Available`)
VALUES
(4,
'105',
'Single',
80.00,
true);

INSERT INTO bookings (RoomId, CustomerName, CheckIn, CheckOut)
VALUES (2, 'John Smith', '2023-12-24', '2023-12-26');



select * from bookings;