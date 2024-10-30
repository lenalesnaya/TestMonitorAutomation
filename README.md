# TestMonitorAutomation

Checklist

GUI
Positive
1. Сheck of the field "Name" of test case suite for entering limit values ​​(1-100 characters)
2. Check of the popup message "Test suite <test suite name> created"
3. Adding of a test suite check.
4. Deleting of a test suite check.
5. "Add Test Suite" dialog window check.
6. Load of an avatar (image that is less or equal to 2048 kb) check.
Negative
1. Check of entering incorrect data (only 1-100 spaces) into test case suite "Name" field.
2. Check of entering data that exceeds the limit values (0 and 101 symbols) into test case suite "Name" field.
3. (crash test) Adding of a test suite with negative space value of test suite name field.

API
-Get-
Positive
1. Retrieve a single project
2. Retrieve a single test suite
3. Retrieve a single test case
Negative
1. Retrieve an unexisting project
2. Retrieve an unexisting test suite
-Post-
1. Create a project
2. Create a test suite
3. Create a test case
