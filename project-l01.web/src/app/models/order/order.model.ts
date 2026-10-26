import { OrderItem } from './order-item.model';
import { Customer } from '../customer/customer.model';

export interface Order {
  id: number;
  customer: Customer;
  status: string;
  total: number;
  items: OrderItem[];
}
