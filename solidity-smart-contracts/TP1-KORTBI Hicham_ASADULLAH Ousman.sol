pragma solidity ^0.4.0;

// Système de vote se basant sur le pour ou le contre d'une proposition proposé

contract voteSystem {
	// Propriétaire de la proposition
	address public owner;

	// Durée du temps de vote de la propositon (en minutes)
	uint public timeVote;

	// Membres participant au vote
	mapping (address => bool) public members;

	struct Proposal {
		string description;
		// Membres participant au vote et si ils ont voté
		mapping (address => bool) voted;
		bool[] votes;
		uint end;
		bool adopted;
		uint voteCount;
	}

	// Tableau de propositions
	Proposal[] proposals;

	// Ejecte tout utilisateur qui n'est pas le propriétaire
    modifier ownerOnly(){
        if (msg.sender != owner) throw;
        _;
    }

   // Ejecte tout utilisateur qui n'est pas membre
   modifier memberOnly(){
        if (!members[msg.sender]) throw;
        _;
    }

   // Si la proposition correspondant à cet index n'est pas ouverte au vote, la fonction n'est pas exécutée
    modifier isOpen(uint index) {
        if(now > proposals[index].end) throw;
        _;
    }
    
    // Vérifie si le temps limité avant la fin du vote de la prposition est écoulée
    modifier isClosed(uint index) {
        if(now < proposals[index].end) throw;
        _;
    }
    
    // Si le compte (msg.sender) a déjà vôté pour cette proposition, la fonction n'est pas exécutée
    modifier didNotVoteYet(uint index) {
        if(proposals[index].voted[msg.sender]) throw;
        _;
    }

     // Fonction de modification du temps seulement par le propriétaire
    function setTimeVote(uint newTimeVote) ownerOnly() {
        timeVote = newTimeVote;
    }
    
    // Envoie les résultats de la proposition une fois le temps écoulé dans executeProposal()
    event Results(address from, bytes32 msg);

	// Constructeur
	function voteSystem(uint votingTime) {
		owner=msg.sender;
		setTimeVote(votingTime);
		}

	// Ajout des membres participant au vote de la proposition
    function addMember(address newMember) ownerOnly() {
        members[newMember] = true;
    }

    // Ajouter une proposition seulement par le propriétaire (celui qui a déployé le contrat)
    function addProposal(string description) ownerOnly() constant returns (uint end){
        uint proposalID = proposals.length++;
       
        Proposal p = proposals[proposalID];
        
        // Description de la proposition
        p.description = description;
        
        // Temps de votes en minutes
        p.end = now + timeVote * 1 minutes;
        end=p.end;
    }

    // Voter pour une proposition (membres exclusivement de la proposition)
    function vote(uint index, bool vote) memberOnly() isOpen(index) didNotVoteYet(index) {
        proposals[index].votes.push(vote);
        proposals[index].voted[msg.sender] = true;
    }

    // Obtenir le résultat d'une proposition
    function executeProposal(uint index) isClosed(index) constant returns (bytes32 results){
        uint yes;
        uint no;
        bool[] votes = proposals[index].votes;

        // On compte les pour et les contre
        for(uint counter = 0; counter < votes.length; counter++) {
            if(votes[counter]) {
                yes++;
            } else {
                no++;
            }
        }
        // p.adopted=false par défaut pas besoin de else
            if(yes > no) {
                proposals[index].adopted = true; 
                Results(msg.sender,"La proposition a été accepté");
                results="Pour";
            }
            else{
                Results(msg.sender,"Non accepté");
                results="Contre";
            }
    }
    
    // Kills
    function kill() ownerOnly() {
        suicide(msg.sender);
	}
}