# Devolutions.AvaloniaTheme.DevExpress

**NOTE:** This theme is still in active development and we are currently not maintaining a detailed change log.
Please see commits if you're curious. However we will do our best to call out key changes in this log.

## v2025.07.14

- BREAKING: Input controls and TextBlock are now all designed to play nicely (and consistently) when dropped into
  layouts with only their default properties. Depending on your usage or the work-arounds you may have applied to fix
  previous alignment issues, you may now see unwanted changes in your layouts.
  <br /><br />Controls now:
  - don't stretch to fill the height of their container
  - have no default margins of their own
  - align vertically centred