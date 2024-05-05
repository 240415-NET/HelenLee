Proposal

Presentation -

- Main Menu
  1.  New User
  2.  Existing User
  3.  Exit Program

- Trip Menu
  1.  Create new trip
  2.  View existing trip
  3.  Update existing trip
  4.  Delete trip
  5.  Done!

Models -

- User
  - userId (int)
  - userName (string)
  - password (string)
  - role (string)

- Trip
  - tripID (int)
  - Destination (string)
  - Description (string)
  - tripType (string) (individual or group)
  - Start Date (DateTime)
  - End Date (DateTime)
  - Cost (double)

- Group Trip (Inherit Trip base class)
  - groupSize (int)
  - groupActivity (string)

Additional Notes:

- Multiple users can manage a trip.
  - Regular Users: create new trips, view own trips, update and delete trips
  - Admin: Create, read, update and delete trips, manage user accounts, etc.
  - Guests: Limited access. Can view public trips/ specific information with no ability to create or modify trips.
