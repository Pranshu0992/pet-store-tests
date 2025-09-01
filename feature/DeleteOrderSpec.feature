Feature: Delete Order Endpoint
  As a user of the Petstore API
  I want to make sure I can delete 
  order using an order Id

  Scenario: Delete order by ID
    Given an order with ID 321 exists
    When I DELETE "/store/order/321"
    Then the response status should be 200
