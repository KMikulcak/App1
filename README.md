This app needs to refresh its content every few seconds - so I use a async method Run -> Refresh(), to get the Data from the DataSource and renew the values in the Page

The app runs on Android emulator as intended, but on Windows devices i have the problem that after the first refresh, the Label in the ListView loses its value.

If you rotate or change the Page the Label ist visible again, until the next refresh
