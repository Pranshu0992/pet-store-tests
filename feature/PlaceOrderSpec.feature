Feature: Place Order Endpoints
  As a user of the Petstore API
  I want to make sure I place order successfully
  with correct request payload and authorization

  Scenario: Place an order for a pet
    Given I have a valid order payload
    When I POST the order to "/store/order"
    Then the response status for place order should be 200

  Scenario: Place order with invalid payload
    Given I have an invalid order payload
    When I POST the order to "/store/order"
    Then the response status for place order should be 400

#  Scenario: Place order without authentication
#    Given I have a valid order payload
#    And I am not authenticated to place order
#    When I POST the order to "/store/order"
#    Then the response status for place order should be 401
