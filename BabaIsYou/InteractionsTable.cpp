#include "InteractionsTable.h"

InteractionsTable::InteractionsMatrix InteractionsTable::table;

void InteractionsTable::init() {
	table = InteractionsMatrix(TypeStack::N_TYPES,InteractionsVector(N_INTERACTIONS));
	for (int i = 0; i < TypeStack::N_TYPES; ++i) {
		for (int j = 0; j < N_INTERACTIONS; ++j) {
			table[i][j] = new NullInteraction();
		}
	}
}

InteractionsTable::InteractionsVector const& InteractionsTable::getInteractions(Type const& t) {
	return table[t.id - 1];
}

void InteractionsTable::insert(Type const& t, Interaction* it) {
	if (!find(t, it->ID())) {
		delete table[t.id - 1][it->ID()];
		table[t.id - 1][it->ID()] = it;
	}
		
}



bool InteractionsTable::find(Type const& t, int id) {
	return table[t.id - 1][id]->ID() != NullInteraction::NULL_ID;
}


void InteractionsTable::free() {
	
	for (int i = 0; i < TypeStack::N_TYPES; ++i) {
		for (int j = 0; j < N_INTERACTIONS; ++j) {
			Interaction* pointer = table[i][j];
			delete pointer;
		}
	}
	
}