Feature: Get Order Endpoint
  As a user of the Petstore API
  I can fetch the details order 
  using an order Id

  Scenario: Get order by ID
    Given an order with ID 123 exists
    When I GET "/store/order/123"
    Then the response status should be 200
    And the response should contain the order details
