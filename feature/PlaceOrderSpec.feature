Feature: Place Order Endpoints
  As a user of the Petstore API
  I want to make sure I place order successfully
  with correct request payload and authorization

  Scenario: Place an order for a pet
    Given I have a valid order payload
    When I POST the order to "/store/order"
    Then the response status should be 200
    And the response should contain the order details
