<template>
  <!-- Главная страница -->
  <div id="homeView" class="columns is-desktop">

    <div class="filter-block  column is-one-fifth">
      <div class="search-field">
        <div class="field">
          <div class="control">
            <v-filter-group uniqName="search" inputType="text" legend="Поиск по строке" :valueAsPlaceholder="true"
              :options="[ {name:'', value: 'Поиск...' }]" v-on:onchange="(data)=> this.search = data" />
          </div>
        </div>
      </div>


      <div class="filter-groups">
        <v-filter-group uniqName="work" inputType="select" legend="Типы работы" :options="[
          {name:'type', value:'none', text:'Выберите тип работы'},
          {name:'type', value:'tradition', text:'традицишионал'},
          {name:'type', value:'digital', text:'диджитал'},
          {name:'type', value:'animation', text:'анимация'},
        ]" v-on:onchange="(data)=> this.work = data" />

        <v-filter-group uniqName="price" inputType="number" legend="Ценовой диапазон" :valueAsPlaceholder="true"
          :options="[
            {name:'min', value:0, text:'От '},
          ]" v-on:onchange="(data)=> this.price_min = data" />

        <v-filter-group uniqName="price" inputType="number" legend="" :valueAsPlaceholder="true" :options="[
          {name:'max', value:0, text:'До '},
        ]" v-on:onchange="(data)=> this.price_max = data" />

        <v-filter-group uniqName="style" inputType="select" legend="Типы лота" :options="[
          {name:'type', value:'none', text:'Выберите тип лота'},
          {name:'type', value:'realism', text:'реализм'},
          {name:'type', value:'styling', text:'стилизация'},
          {name:'type', value:'antro', text:'антро'},
        ]" v-on:onchange="(data)=> this.style = data" />
      </div>


    </div>

    <div class="content-block column">
      <div class="container">

        <div v-if="AUCTIONS_SORTED.length == 0" class="error">
          Нет подходящих аукционов
        </div>

        <div v-else class="mb-6 columns is-multiline">
          <vAuctionCard v-for="auc in AUCTIONS_SORTED" :key="auc.auctionInfo.id" :auction="auc" />
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import vFilterGroup from '@/components/filter/v-filter-group.vue'
import vAuctionCard from '@/components/auction/v-auction-card.vue'
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'HomeView',
  data() {
    return {
      search: "",
      price_min: 0,
      price_max: 0,
      work: "none",
      style: "none",
    }
  },
  components: {
    vFilterGroup,
    vAuctionCard
  },
  computed: {
    ...mapGetters('auctions', [
      'AUCTIONS'
    ]),

    AUCTIONS_SORTED: function () {

      let result = this.AUCTIONS.map(e => e);

      if (this.search != "") {
        result = result.filter(e => e.auctionInfo.name.includes(this.search));
      }

      if (this.price_min != "") {
        result = result.filter(e => this.getMaxStavka(e) >= this.price_min);
      }
      if (this.price_max != "") {
        result = result.filter(e => this.getMaxStavka(e) <= this.price_max);
      }

      return result;
    }

  },
  methods: {
    ...mapActions('auctions', [
      'auctionList'
    ]),
    updateSearch: function (data) {
      console.dir(data);
    },

    getMaxStavka: function (auc) {
      return auc.listStavka.reduce((a, b) => {
        return { size: Math.max(a.size, b.size) };
      }, { size: auc.auctionInfo.startStavka }).size;
    }
  },
  mounted() {
  }
}
</script>

<style lang="scss" scoped>
.filter-block {
  padding: 1rem;
  border: 2px solid black;
  border-radius: 2rem;
  max-height: 30em;
}

.content-block {}
</style>
