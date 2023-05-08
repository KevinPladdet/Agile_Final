using UnityEngine;

public class enemyStateController
{
    // An array to store all possible states that the enemy can be in
    public AiState[] states;

    // The agent that this state controller is controlling
    public AiAgent agent;

    // The current state of the enemy
    public AiStateId currentState;

    // Constructor that initializes the state array
    public enemyStateController(AiAgent agent)
    {
        this.agent = agent;

        // Get the number of values in the AiStateId enum and create a new array with that size
        int numStates = System.Enum.GetNames(typeof(AiStateId)).Length;
        states = new AiState[numStates];
    }

    // Method to register a new state with the controller
    public void RegisterState(AiState state)
    {
        // Get the index of the state in the array based on its ID
        int index = (int)state.GetId();

        // Add the state to the array
        states[index] = state;
    }

    // Method to retrieve a state from the array based on its ID
    public AiState GetState(AiStateId stateId)
    {
        // Get the index of the state in the array based on its ID
        int index = (int)stateId;

        // Return the state at that index in the array
        return states[index];
    }

    // Method called every frame to update the current state
    public void Update()
    {
        // Get the current state from the array and call its Update method, passing in the agent
        GetState(currentState)?.Update(agent);
    }

    // Method to change the current state
    public void ChangeState(AiStateId newState)
    {
        Debug.Log("enemyStateController: Changing state to " + newState);

        // Call the Exit method of the current state, if there is one
        GetState(currentState)?.Exit(agent);

        // Set the new state as the current state
        currentState = newState;

        // Call the Enter method of the new state, if there is one
        GetState(currentState)?.Enter(agent);
    }

    // Method called when the enemy collides with a non-trigger collider
    public void OnCollisionEnter(Collision collision)
    {
        // Call the OnCollisionEnter method of the current state, passing in the agent
        GetState(currentState)?.OnCollisionEnter(agent);
    }

    //Method called when the enemy collides with a collider
    public void OnTriggerEnter(Collider other)
    {
        GetState(currentState)?.OnTriggerEnter(agent);
    }
}
// i used chat gtp to comment this because i forgor
