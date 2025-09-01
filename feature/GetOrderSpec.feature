Feature: Get Order Endpoint
  As a user of the Petstore API
  I can fetch the details of an order using an order Id

  Scenario: Get order by ID
    Given an order with ID 5 is created
    When I GET "/store/order/5"
    Then the response status for get order should be 200
    And the order details returned should be corect based on created order

  Scenario: Get order with non-existent ID
    When I GET "/store/order/999999"
    Then the response status for get order should be 404

#  Scenario: Get order without authentication
#    Given an order with ID 123 exists
#    And I am not authenticated to get order details
#    When I GET "/store/order/123"
#    Then the response status for get order should be 401
