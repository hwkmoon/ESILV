pragma solidity ^0.4.10;

contract Token {
    /* This is a slight change to the ERC20 base standard.
    function totalSupply() constant returns (uint256 supply);
    is replaced with:
    uint256 public totalSupply;
    This automatically creates a getter function for the totalSupply.
    This is moved to the base contract since public getter functions are not
    currently recognised as an implementation of the matching abstract
    function by the compiler.
    */
    /// total amount of tokens
    uint256 public totalSupply;

    /// @param _owner The address from which the balance will be retrieved
    /// @return The balance
    function balanceOf(address _owner) constant returns (uint256 balance);

    /// @notice send `_value` token to `_to` from `msg.sender`
    /// @param _to The address of the recipient
    /// @param _value The amount of token to be transferred
    /// @return Whether the transfer was successful or not
    function transfer(address _to, uint256 _value) returns (bool success);

    /// @notice send `_value` token to `_to` from `_from` on the condition it is approved by `_from`
    /// @param _from The address of the sender
    /// @param _to The address of the recipient
    /// @param _value The amount of token to be transferred
    /// @return Whether the transfer was successful or not
    function transferFrom(address _from, address _to, uint256 _value) returns (bool success);

    /// @notice `msg.sender` approves `_spender` to spend `_value` tokens
    /// @param _spender The address of the account able to transfer the tokens
    /// @param _value The amount of tokens to be approved for transfer
    /// @return Whether the approval was successful or not
    function approve(address _spender, uint256 _value) returns (bool success);

    /// @param _owner The address of the account owning tokens
    /// @param _spender The address of the account able to transfer the tokens
    /// @return Amount of remaining tokens allowed to spent
    function allowance(address _owner, address _spender) constant returns (uint256 remaining);

    event Transfer(address indexed _from, address indexed _to, uint256 _value);
    event Approval(address indexed _owner, address indexed _spender, uint256 _value);
}

contract fidelityPoints is Token {

    // Propriétaire de la proposition
    address public owner;

    // Array with all balances
    mapping (address => uint256) public balanceF;

    // Points de fidélités initiaux
    uint256 public initialPoints;
    
    function balanceOf(address _owner) constant returns (uint256 balance){
        balanceF[_owner]=initialPoints;
        balance=balanceF[_owner];
    }


    // Ejecte tout utilisateur qui n'est pas le propriétaire
    modifier ownerOnly(){
        if (msg.sender != owner) throw;
        _;
    }

    // Fonction de modification du nombre de points
    function setInitialPoint(uint newPoints) ownerOnly() {
        initialPoints = newPoints;
    }
    // Avertis le client d'un transfert de points
    event Results(address from, bytes32 msg);
    // Constructeur
    /* Initializes contract with initial supply fidelity points to the owner of the contract */
    function fidelityPoints(uint initialSupply) {
        owner=msg.sender;
        setInitialPoint(initialSupply);
        // Give the creator all initial fidelity points
        balanceOf(msg.sender);              
    }
    /* Transfer of fidelity points */

    function transfer(address _to, uint256 _value) ownerOnly returns (bool success) {
        success=false;
        if (balanceOf(msg.sender) < _value) throw;
        if (balanceOf(_to) + _value < balanceOf(_to)) throw;
        balanceF[msg.sender] -= _value;                     
        balanceF[_to] += _value;
        Results(msg.sender,"Points transférés");
        success=true;
    }

    // Kills
    function kill() ownerOnly() {
        suicide(msg.sender);
    }
    
}