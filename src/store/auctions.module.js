import Axios from 'axios'
import config from '@/../config'

const auctionApi = config.apiUrl + '/auction';

const auctionAddApi = auctionApi + '/add';
const auctionListApi = auctionApi + '/list';
const auctionStavkaApi = auctionApi + '/stavka/';
const auctionHistoryListByUserApi = auctionApi + '/history/';
const auctionStavkaListApi = auctionApi + '/';

const state = {
  auctions: [],
};

const actions = {

  auctionAdd({
    commit,
    state
  }, data) {
    return Axios.get(auctionAddApi, {
      method: "POST",
      params: {
        name: data.name,
        idUser: data.idUser,
        image: data.image,
        timeStart: data.timeStart,
        timeEnd: data.timeEnd,
        startStavka: data.startStavka,
        stepStavka: data.stepStavka
      }
    }).then((response) => {

      if (response.status == 201) {
        /* TODO: Какой формат ответа? */
        return response.data;
      } else {
        return false; /* TODO: Обработать ошибку добавления */
      }

    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  /* FIXME: Функция требует свое фикса, нет списка ставок на аукционе */
  auctionList({
    commit,
    state
  }) {
    return Axios.get(auctionListApi, {
      method: "GET"
    }).then((response) => {

      if (response.status !== 200) {
        return false; /* TODO: Обработать ошибку получения данных */
      }

      /*
        AuctionInfo()

        id : int
        name : string
        idUser : int
        image : string
        timeStart : string
        timeEnd : string
        startStavka : int
        stepStavka : int
        description : string 
      */

      // response.data = response.data.map((auc) => {
      //   auc.history = auc.history.sort((a, b) => {
      //     return a.size < b.size
      //   });
      //   return auc;
      // });

      // if (JSON.stringify(response.data) !== JSON.stringify(state.auctions))
      // TODO: Еще нужно так-то список ставок получать.... 
      commit('SET_AUCTIONS', response.data);
      return true;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  auctionStavka({
    commit,
    state,
    actions
  }, stavka) {
    return Axios.get(auctionStavkaApi + stavka.auctionId, {
      method: "POST",
      params: {
        idUser: stavka.idUser,
        time: stavka.time,
        size: stavka.size
      }
    }).then((response) => {
      if( response.status == 200 ){
        return true;
      }
      else {
        return false;
      }
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  auctionHistoryListByUser({
    commit,
    state
  }, data) {
    return Axios.get(auctionHistoryListByUserApi + data.userId, {
      method: "GET"
    }).then((response) => {
      if(response.status == 200){
        return response.data; // Список аукционов, без информации о ставках
      }
      else {
        return false; /* TODO: Обработать ошибку получения данных */
      }
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },

  /* TODO: Аукцион по ID со списком ставок по пользователю, FIXME: НЕ ЛОГИЧНО */
  /* TODO: Какой формат запроса? */
  auctionStavkaList({
    commit,
    state
  }, data) {
    return Axios.get(auctionStavkaListApi + data.aucId, {
      method: "GET"
    }).then((response) => {
      if (response.status !== 200) {
        return false; /* TODO: Обработать ошибку получения данных */
      }
      /* TODO: Какой формат ответа? */
      return response.data;
    }).catch((error) => {
      console.log(error);
      return error;
    });
  },
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
  auctionStavka: (state, stavka) => {
    state.auctions.map((auc) => {
      if (auc.id == stavka.auctionId) {
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
