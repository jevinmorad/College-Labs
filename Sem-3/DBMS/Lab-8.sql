CREATE TABLE SALES_DATA(
	REGION VARCHAR(50),
	PRODUCT VARCHAR(50),
	AMOUNT INT,
	_YEAR INT,
);

INSERT INTO SALES_DATA VALUES('NORTH AMERICA', 'WATCH', 1500, 2023)INSERT INTO SALES_DATA VALUES('EUROPE', 'MOBILE', 1200, 2023)
INSERT INTO SALES_DATA VALUES('ASIA', 'WATCH', 1800, 2023)
INSERT INTO SALES_DATA VALUES('NORTH AMERICA', 'TV', 900, 2024)
INSERT INTO SALES_DATA VALUES('EUROPE', 'WATCH', 2000, 2024)
INSERT INTO SALES_DATA VALUES('ASIA', 'MOBILE', 1000, 2024)
INSERT INTO SALES_DATA VALUES('NORTH AMERICA', 'MOBILE', 1600, 2023)
INSERT INTO SALES_DATA VALUES('EUROPE', 'TV', 1500, 2023)
INSERT INTO SALES_DATA VALUES('ASIA', 'TV', 1100, 2024)
INSERT INTO SALES_DATA VALUES('NORTH AMERICA', 'WATCH', 1700, 2024)


--Part – A:
--1. Display Total Sales Amount by Region.
SELECT REGION,SUM(AMOUNT) AS TOTAL_SALES_AMOUNT FROM SALES_DATA GROUP BY REGION
--2. Display Average Sales Amount by Product
SELECT PRODUCT,AVG(AMOUNT) AS AVG_SELS_AMOUNT FROM SALES_DATA GROUP BY PRODUCT
--3. Display Maximum Sales Amount by Year
SELECT _YEAR,MAX(AMOUNT) AS MAX_SELS_AMOUNT FROM SALES_DATA GROUP BY _YEAR
--4. Display Minimum Sales Amount by Region and Year
SELECT _YEAR,MIN(AMOUNT) AS MAX_SELS_AMOUNT FROM SALES_DATA GROUP BY _YEAR
--5. Count of Products Sold by Region
SELECT REGION,COUNT(PRODUCT) AS TOTAL_PRODUCT FROM SALES_DATA GROUP BY REGION
--6. Display Total Sales Amount by Year and Product
SELECT PRODUCT,_YEAR,SUM(AMOUNT) AS TOTAL_AMOUNT FROM SALES_DATA GROUP BY _YEAR,PRODUCT
--7. Display Regions with Total Sales Greater Than 5000
SELECT REGION FROM SALES_DATA GROUP BY REGION HAVING SUM(AMOUNT)>5000
--8. Display Products with Average Sales Less Than 10000
SELECT PRODUCT FROM SALES_DATA GROUP BY PRODUCT HAVING AVG(AMOUNT)>5000
--9. Display Years with Maximum Sales Exceeding 500
SELECT _YEAR FROM SALES_DATA GROUP BY _YEAR HAVING MAX(AMOUNT)>500
--10. Display Regions with at Least 3 Distinct Products Sold.
SELECT REGION FROM SALES_DATA GROUP BY REGION HAVING COUNT(PRODUCT)>=3
--11. Display Years with Minimum Sales Less Than 1000
SELECT _YEAR FROM SALES_DATA GROUP BY _YEAR HAVING MIN(AMOUNT)<1000
--12. Display Total Sales Amount by Region for Year 2023, Sorted by Total Amount



--Part – B:
--1. Display Count of Orders by Year and Region, Sorted by Year and Region
--2. Display Regions with Maximum Sales Amount Exceeding 1000 in Any Year, Sorted by Region
--3. Display Years with Total Sales Amount Less Than 1000, Sorted by Year Descending
--4. Display Top 3 Regions by Total Sales Amount in Year 2024


--Part – C:
--1. Display Products with Average Sales Amount Between 1000 and 2000, Ordered by Product Name
--2. Display Years with More Than 5 Orders from Each Region
--3. Display Regions with Average Sales Amount Above 1500 in Year 2023 sort by amount in descending.
--4. Find out region wise duplicate product.
--5. Find out region wise highest sales amount.