Feature: Get Store Inventory endpoint
  As a user of the Petstore API
  I want to get the status of inventory
  and the details of the inventory

  Scenario: Get inventory details
    When I GET "/store/inventory"
    Then the response status should be 200
    And the response should contain inventory details
