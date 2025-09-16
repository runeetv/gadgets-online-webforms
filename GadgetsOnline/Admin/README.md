# Admin Product Management System

## Overview
This admin section provides comprehensive product management functionality for the Gadgets Online e-commerce application using ASP.NET Web Forms.

## Features

### Product Management Page (ManageProducts.aspx)
- Located at: `/Admin/ManageProducts.aspx`
- Uses ViewState for state management across postbacks
- Implements a UserControl (`ProductManagement.ascx`) for modular functionality

### Key Functionalities

1. **View Products**
   - Displays all products in a GridView with pagination
   - Shows product images, names, prices, and categories
   - Supports sorting and paging

2. **Add New Products**
   - Form to add new products with validation
   - Required field validation for name, price, and category
   - Price range validation ($0.01 - $10,000)
   - Optional image upload with file type validation (JPG, PNG, GIF)
   - Images are stored in `/Images/Products/` directory

3. **Edit Products**
   - Inline editing in GridView
   - Edit product name, price, and category
   - Validation during edit operations
   - Update and Cancel functionality

4. **Delete Products**
   - Delete products with JavaScript confirmation
   - Prevents deletion of products referenced in orders
   - Automatically removes associated image files

5. **Image Management**
   - File upload validation
   - Unique filename generation to prevent conflicts
   - Automatic directory creation
   - Image cleanup on product deletion

## Technical Implementation

### ViewState Usage
- Maintains product list and category data across postbacks
- Reduces database calls during user interactions
- Stores filtering and pagination state

### UserControl Architecture
- `ProductManagement.ascx` - Encapsulates all product management UI and logic
- Reusable component that can be embedded in other admin pages
- Separation of concerns between presentation and business logic

### Validation
- Client-side and server-side validation
- Required field validators
- Range validators for price
- File type validation for images

### Security Considerations
- Input validation and sanitization
- File upload restrictions
- Protection against SQL injection through Entity Framework
- Server-side validation as final security layer

### Error Handling
- Try-catch blocks around database operations
- User-friendly error messages
- Graceful handling of file operations

## File Structure
```
/Admin/
??? ManageProducts.aspx              # Main admin page
??? ManageProducts.aspx.cs           # Page code-behind
??? ManageProducts.aspx.designer.cs  # Designer file
??? Admin.master                     # Admin master page (optional)
??? Admin.master.cs                  # Master page code-behind
??? Admin.master.designer.cs         # Master designer file
??? Controls/
    ??? ProductManagement.ascx          # UserControl markup
    ??? ProductManagement.ascx.cs       # UserControl logic
    ??? ProductManagement.ascx.designer.cs # UserControl designer
```

## Usage Instructions

1. **Navigate to Admin Panel**
   - Go to `/Admin/ManageProducts.aspx`

2. **Add New Product**
   - Fill in product name, price, and select category
   - Optionally upload an image
   - Click "Add Product"

3. **Edit Product**
   - Click "Edit" next to any product
   - Modify fields inline
   - Click "Update" to save or "Cancel" to discard

4. **Delete Product**
   - Click "Delete" next to any product
   - Confirm deletion in the JavaScript prompt
   - Product and associated image will be removed

## Database Dependencies
- Requires `GadgetsOnlineEntities` Entity Framework context
- Uses `Product` and `Category` models
- Checks `OrderDetail` table before allowing deletions

## Future Enhancements
- Bulk operations (delete multiple products)
- Advanced filtering and search
- Product categorization management
- Inventory tracking
- Product image gallery support
- Export/Import functionality