<template>
  <div class='profileView container is-fluid p-6'>

    <div class="container is-fluid">
      <p>
        <b>ID:</b> {{USER.id}}<br>
        <b>Имя:</b> {{USER.name}}<br>
        <b>Почта:</b> {{USER.email}}<br>
        <b class="showOtchet button is-info" v-on:click="showOtchet = !showOtchet">Показать отчет</b>
      </p>
    </div>

    <div class="container is-fluid m-5" v-if="showOtchet == false">
      <h2><b>История аукционов</b></h2>
      <div class=" columns is-multiline">
        <vAuctionCard v-for="auc in AUCTIONS_SORTED" :key="auc.auctionInfo.id" :auction="auc" />
      </div>
    </div>

    <div class="container is-fluid m-5" v-else>
      <h2><b>Отчет за месяц</b></h2>
      <div class=" columns is-multiline">
        <table class="table">
          <!-- class="is-selected" -->
          <thead>
            <tr>
              <th>ID</th>
              <th>Название</th>
              <th>Начальная ставка</th>
              <th>Минимальный шаг</th>
              <th>Начало аукциона</th>
              <th>Окончание аукциона</th>
              <th>Всего ставок</th>
              <th>Лучшая ставка</th>
            </tr>
          </thead>
          <tfoot>
            <tr>
              <th></th>
              <th></th>
              <th></th>
              <th></th>
              <th></th>
              <th></th>

              <th></th>
              <th>{{AUCTIONS_SUM}}</th>
            </tr>
          </tfoot>
          <tbody>
            <tr 
            v-for="auc in AUCTIONS_SORTED2" :key="auc.auctionInfo.id"
            :id="auc.auctionInfo.id"
            v-on:click="this.$router.push({ name: 'auction', query: { id: auc.auctionInfo.id } })"
            >
              <th>{{auc.auctionInfo.id}}</th>
              <td>{{auc.auctionInfo.name}}</td>
              <td>{{auc.auctionInfo.startStavka}}</td>
              <td>{{auc.auctionInfo.stepStavka}}</td>
              <td>{{getData(auc.auctionInfo.timeStart)}}</td>
              <td>{{getData(auc.auctionInfo.timeEnd)}}</td>
              <td>{{auc.listStavka.length}}</td>
              <td>{{getMaxStavka(auc)}}</td>
            </tr>
          </tbody>
        </table>

      </div>
    </div>


  </div>
</template>

<script>
import vAuctionCard from '@/components/auction/v-auction-card.vue'
import { mapGetters } from 'vuex';


export default {
  data() {
    return {
      showOtchet: false,
    }
  },
  components: { vAuctionCard },
  computed: {

    ...mapGetters('users', ['USER']),
    ...mapGetters('auctions', ['AUCTIONS']),

    AUCTIONS_SORTED: function () {

      let result = this.AUCTIONS
        .filter(e => e.auctionInfo.idUser == this.USER.id)
        .sort((a, b) => a.auctionInfo.timeEnd < b.auctionInfo.timeEnd);
      return result;
    },

    AUCTIONS_SORTED2: function () {
      let result = this.AUCTIONS
        .filter(e => e.auctionInfo.idUser == this.USER.id);
      return result;
    },

    AUCTIONS_SUM: function () {
      return this.AUCTIONS
        .filter(e => e.auctionInfo.idUser == this.USER.id)
        .map(e => this.getMaxStavka(e))
        .reduce((a, b) => this.numOr0(a) + this.numOr0(b));
      ;
    }

  },
  methods: {
    numOr0: function (n){
      return isNaN(n) ? 0 : Number(n); },

    getMaxStavka: function ( auction ) { 
      const data = auction.listStavka
      .map( (e) => this.numOr0(e.size) )
      .sort((a, b)=> a <= b); 
      if(data.length > 0) { return data[0]; } else
      return 0;
    },
    getData: function ( data ) { 
      if (data == undefined) {
        return "";
      }
      return new Date(Number(data)).toLocaleDateString()
    }
  },
  mounted() { }
}
</script>

<style lang='scss'>
h2 {
  font-size: 2rem;
  width: 100%;
  text-align: center;
}

.showOtchet {
  color: green;
  background-color: #04ab9b !important;
}
tr:hover{
  background-color: rgb(203, 244, 203);
  cursor: pointer;
}
</style>
