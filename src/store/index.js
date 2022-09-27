import Vuex from 'vuex';
import { users } from './users.module';
import { auctions } from './auctions.module';

export const store = new Vuex.Store({
  modules: {
      users,
      auctions
  }
});
