# Plan: Replace Payment Alert with Invoice

## Goal
When the user clicks **Pay Now** on the payment page and payment succeeds, show a proper invoice/receipt window instead of the current `MessageBox.Show("Payment completed successfully!")`.

## Approach
Build the invoice UI dynamically inside `ProductCatalog.cs` as a modal `Form` (no new files), in line with the existing pattern where all panels in `ProductCatalog` are created at runtime.

## Why this approach
- Keeps everything in one file, matching the current runtime-UI style of `ProductCatalog`.
- Avoids adding new `.cs` / `.Designer.cs` files, which the user previously declined.
- Fast to implement and easy to wire into the existing `btnPayNow_Click` handler.

## Implementation steps
1. Add a `ShowInvoice(int orderId)` method in `ProductCatalog.cs`.
2. In that method:
   - Query `Orders` for the current order (OrderId, OrderDate, UserPhone, UserCity, UserAddress, TotalCost, OrderStatus).
   - Query `OrderItems` for all items belonging to that order.
   - Query `Users` for customer name/email using `UserId`.
   - Query `Payments` for `TransactionId` and `PaymentDate`.
3. Build a new `Form` sized around `520 × 720` with:
   - Header: "INVOICE" / "Payment Receipt" and a green "Paid" badge.
   - Order metadata: Order ID, Date, Customer name/email, phone, city, address.
   - Items list: product name, unit price, quantity, line total.
   - Totals: subtotal and order total.
   - Footer: "Thank you for your purchase!" and a **Continue Shopping** button.
4. In `btnPayNow_Click`, after `CompletePayment` returns `true`:
   - Call `ShowInvoice(pendingOrderId)` instead of `MessageBox.Show`.
   - Wait for the invoice dialog to close, then clear the cart and return to the product list.
5. Build and verify 0 errors.

## Files touched
- `Shopping_Cart/ProductCatalog.cs` only.

## Notes
- All database reads reuse the existing `GetConnectionString()` and `ExecuteQuery()` patterns.
- The invoice will be read-only (modal dialog).
- The Continue Shopping button on the invoice will close the dialog; the main form then performs the same cleanup as today.
