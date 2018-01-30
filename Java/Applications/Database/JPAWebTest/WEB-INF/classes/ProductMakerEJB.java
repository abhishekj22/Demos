package sales;

import javax.ejb.*;
import javax.persistence.*;

@LocalBean
@Stateless
public class ProductMakerEJB{

	@PersistenceContext
	private EntityManager em;

	public int addNewProduct(double price, int stock){
		CounterEntity ctr = em.find(CounterEntity.class, "products");
		int productNo = ctr.getNextValue() + 100;
		ProductEntity entry = new ProductEntity();
		entry.setProductNo(productNo);
		entry.setPrice(price);
		entry.setStock(stock);
		em.persist(entry);
		return productNo;
	}
}


