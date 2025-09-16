# Admin Authentication System

## Overview
This ASP.NET Web Forms application now includes Forms-based authentication for the Admin section. The authentication system prevents unauthorized access to administrative functionality while allowing normal users to browse the public store.

## Default Admin Credentials
- **Username**: `admin`
- **Password**: `admin`

## Features Implemented

### 1. Database Authentication
- New `AdminUser` table in the existing database
- Secure password hashing using SHA256
- Default admin user is automatically created during database initialization
- Support for multiple admin users (can be added directly to the database)

### 2. Forms Authentication
- Configured in `Web.config` with 30-minute timeout
- Sliding expiration (extends session on activity)
- Automatic redirection to login page for unauthorized access
- Remember authentication across browser sessions

### 3. Authorization Rules
- **Public Access**: Main store pages (Default.aspx, Browse.aspx, etc.)
- **Protected**: All pages in `/Admin/` folder require authentication
- **Exceptions**: Login.aspx and Logout.aspx are accessible to everyone

### 4. User Interface
- Professional login page with validation
- Welcome message showing current logged-in user
- Logout functionality with session cleanup
- Navigation links between admin and store sections

## File Structure
```
/Admin/
??? Login.aspx              # Login form
??? Login.aspx.cs           # Login logic
??? Login.aspx.designer.cs  # Login designer file
??? Logout.aspx             # Logout confirmation
??? Logout.aspx.cs          # Logout logic
??? Logout.aspx.designer.cs # Logout designer file
??? ManageProducts.aspx     # Protected admin page (updated)
??? Controls/
    ??? ProductManagement.ascx  # Admin user control

/Models/
??? AdminUser.cs            # User model for authentication
??? GadgetsOnlineEntities.cs # Updated context with AdminUsers
??? GadgetsOnlineDBInitializer.cs # Updated with default user

/Services/
??? AuthenticationService.cs # Authentication business logic
```

## Security Features

### Password Security
- SHA256 hashing algorithm
- No plain text passwords stored
- Password verification through hash comparison

### Session Management
- Secure authentication cookies
- Automatic logout on browser close (configurable)
- Protection against session hijacking

### Access Control
- Directory-level authorization
- Automatic redirection for unauthorized access
- Clean logout with session cleanup

## Usage Instructions

### For Administrators
1. Navigate to `/Admin/ManageProducts.aspx` (will redirect to login)
2. Enter credentials: `admin` / `admin`
3. Access product management functionality
4. Use "Logout" link when finished

### For End Users
- No authentication required for public store pages
- Shopping cart and checkout work as before
- No impact on existing functionality

## Database Changes
The system adds one new table:
- `AdminUsers` - Stores admin user credentials and metadata

Existing tables remain unchanged, ensuring backward compatibility.

## Configuration
Key settings in `Web.config`:
- `authentication mode="Forms"`
- `loginUrl="~/Admin/Login.aspx"`
- `timeout="30"` (minutes)
- Directory-specific authorization rules

## Adding New Admin Users
To add new admin users, insert directly into the database:

```sql
INSERT INTO AdminUsers (Username, PasswordHash, Email, IsActive, CreatedDate)
VALUES ('newadmin', 'sha256_hash_of_password', 'admin@company.com', 1, GETDATE())
```

Use the `AuthenticationService.HashPassword()` method to generate password hashes.

## Future Enhancements
- Password reset functionality
- Role-based authorization (different admin levels)
- User management interface
- Password complexity requirements
- Account lockout after failed attempts
- Audit logging for admin actions