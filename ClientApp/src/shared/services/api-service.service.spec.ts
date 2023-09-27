import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ApiServiceService } from './api-service.service'; // Use the correct relative path here
import { environment } from 'src/environments/environment.prod';

describe('ApiServiceService', () => {
  let apiService: ApiServiceService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ApiServiceService],
    });

    apiService = TestBed.inject(ApiServiceService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  })

  it('should be created', () => {
    expect(apiService).toBeTruthy();
  });

  it('should make a GET request with an ID', () => {
    const endpoint = 'example';
    const id = 1;
    const responseData = { id, name: 'Test Data' };

    apiService.GetById(endpoint, id).subscribe((response) => {
      expect(response).toEqual(responseData);
    });

    const req = httpTestingController.expectOne(`${environment.apiUrl}/${endpoint}/${id}`);
    expect(req.request.method).toEqual('GET');

    req.flush(responseData);
  });

  it('should make a POST request', () => {
    const endpoint = 'example';
    const requestData = { name: 'Test Data' };
    const responseData = { id: 1, ...requestData };

    apiService.Post(endpoint, requestData).subscribe((response) => {
      expect(response).toEqual(responseData);
    });

    const req = httpTestingController.expectOne(`${environment.apiUrl}/${endpoint}`);
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(requestData);

    req.flush(responseData);
  });

  it('should make a POST request with an ID', () => {
    const endpoint = 'example';
    const id = 1;
    const requestData = { name: 'Test Data' };
    const responseData = { id, ...requestData };

    apiService.PostById(endpoint, id, requestData).subscribe((response) => {
      expect(response).toEqual(responseData);
    });

    const req = httpTestingController.expectOne(`${environment.apiUrl}/${endpoint}/${id}`);
    expect(req.request.method).toEqual('POST');
    expect(req.request.body).toEqual(requestData);

    req.flush(responseData);
  });






  
});
