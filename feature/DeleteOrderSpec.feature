Feature: Delete Order Endpoint
  As a user of the Petstore API
  I want to make sure I can delete order using an order Id

  Scenario: Delete order by ID
    Given an order with ID 4 exists
    When I DELETE "/store/order/4"
    Then the response status for delete order should be 200

  Scenario: Delete order with non-existent ID
    When I DELETE "/store/order/999999"
    Then the response status for delete order should be 404

#  Scenario: Delete order without authentication
#    Given an order with ID 321 exists
#    And I am not authenticated to delete order
#   When I DELETE "/store/order/321"
#    Then the response status for delete order should be 401
