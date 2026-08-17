# Refactor Improvements

[] Replace string arrays with real models/records for report rows.
[] Keep validation and retry flow in the input layer instead of throwing exceptions immediately.
[] Reduce repeated CSV/HTML formatting logic with shared helpers or strategy classes.
[] Make the null object pattern more intentional: decide whether invalid input should no-op, prompt again, or fail clearly.
[] Add stronger domain types beyond enums for report types and formats if the app grows.
[] Consider a more extensible registration-based factory instead of a switch-like mapping.
[] Improve UX by reprompting on invalid input instead of exiting abruptly.
