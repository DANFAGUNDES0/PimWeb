import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoTicketComponent } from './novo-ticket.component';

describe('NovoTicketComponent', () => {
  let component: NovoTicketComponent;
  let fixture: ComponentFixture<NovoTicketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NovoTicketComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NovoTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
