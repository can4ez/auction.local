<template>
  <div class='profileView container is-fluid p-6'>
    <p>ID: {{USER.id}}</p>
    <p>Имя: {{USER.name}}</p>
    <p>Почта: {{USER.email}}</p>

    <h2>История аукционов: </h2>

    <div class="m-5 columns is-multiline">
      <vAuctionCard 
      v-for="auc in AUCTIONS_SORTED" 
      :key="auc.auctionInfo.id" 
      :auction="auc" />
    </div>

  </div>
</template>

<script>
import vAuctionCard from '@/components/auction/v-auction-card.vue'
import { mapGetters } from 'vuex';


export default {
  data() {
    return {
    }
  },
  components: { vAuctionCard },
  computed: {

    ...mapGetters('users', ['USER']),
    ...mapGetters('auctions', ['AUCTIONS']),

    AUCTIONS_SORTED: function () {
      
      let result = this.AUCTIONS
      .filter(e => e.auctionInfo.idUser == this.USER.id )
      .sort((a, b) => a.auctionInfo.timeEnd < b.auctionInfo.timeEnd);
      return result;
    },

  },
  methods: {
  },
  mounted() { }
}
</script>

<style lang='scss'>

</style>
