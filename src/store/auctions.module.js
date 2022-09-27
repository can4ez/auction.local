import Axios from 'axios'
import config from '@/../config'

const state = {
  auctions: [],
};

const actions = {
  GET_AUCTIONS_FROM_API({
    commit, state 
  }) {
    return Axios.get(config.apiUrl + '/auctions', {
      method: "GET"
    }).then((auctions) => {

      auctions.data = auctions.data.map((auc)=>{
        auc.history = auc.history.sort((a, b) => { return a.size < b.size });
        return auc;
      });

      if(JSON.stringify(auctions.data) !== JSON.stringify(state.auctions))
        commit('SET_AUCTIONS', auctions.data);
      return auctions;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },
  ADD_STAVKA({commit, state, actions}, stavka){
    // return Axios.get(config.apiUrl + '/auctions/stavka', {
    //   method: "GET"
    // }).then((auctions) => {

    //   if(JSON.stringify(auctions.data) !== JSON.stringify(state.auctions))
    //     commit('SET_AUCTIONS', auctions.data);
    //   return auctions;
    // }).catch((error) => {
    //   console.log(error);
    //   return error;
    // });
  }
};
const getters = {
  AUCTIONS(state) {
    return state.auctions;
  }
};
const mutations = {
  SET_AUCTIONS: (state, auctions) => {
    console.log("Update auctions...")
    state.auctions = auctions;
  },
  ADD_STAVKA: (state, stavka)=>{
    state.auctions.map((auc)=>{
      if(auc.id == stavka.auctionId){
        auc.history.push(0, {
          idUser: stavka.idUser,
          time: stavka.time,
          size: stavka.size
        });
      }
      return auc;
    })
  }
};

export const auctions = {
  namespaced: true,
  state,
  actions,
  mutations,
  getters
};
