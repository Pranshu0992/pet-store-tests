Feature: Store Endpoints
  As a user of the Petstore API
  I want to interact with the store endpoints
  So that I can manage orders and inventory

  Scenario: Place an order for a pet
    Given I have a valid order payload
    When I POST the order to "/store/order"
    Then the response status should be 200
    And the response should contain the order details

  Scenario: Get order by ID
    Given an order with ID 1 exists
    When I GET "/store/order/1"
    Then the response status should be 200
    And the response should contain the order details

  Scenario: Delete order by ID
    Given an order with ID 1 exists
    When I DELETE "/store/order/1"
    Then the response status should be 200
    And the response should confirm deletion

  Scenario: Get inventory
    When I GET "/store/inventory"
    Then the response status should be 200
    And the response should contain inventory details
